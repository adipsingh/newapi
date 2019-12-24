import { Component, OnInit, OnDestroy, ElementRef, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AttachmentService } from '../../services/attachment.service';
import { UploadService } from '../../services/upload.service';
import { Attachment } from '../../models';
import { FileStatus } from '../../enum';
import { PrepareDatePipe } from '../../shared/pipes/prepare-date.pipe';
import { PhraseGeneratorService } from '../../services/phrase-generator.service';
import { DialogService } from '../../services/dialog.service';


@Component({
  selector: 'am-upload-progress',
  templateUrl: './upload-progress.component.html',
  styleUrls: ['./upload-progress.component.scss']
})
export class UploadProgressComponent implements OnInit, OnDestroy, AfterViewInit {

  phrase: string;
  downloadUrl: string;
  attachment: Attachment = {
    attachmentId: 0,
    name: '',
    totalSize: 0,
    totalCount: 0,
    creationDate: new Date(),
    expiryDate: new Date(),
    userId: 123,
    accountId: 2,
    status: FileStatus.Active,
    downloadUrl: `${window.location.origin}/download`,
    deletionDate: new Date()
  };
  constructor(public uploadService: UploadService,
    public attachmentService: AttachmentService,
    public phraseGeneratorService: PhraseGeneratorService,
    private dialogService: DialogService,
    private activateRoute: ActivatedRoute,
    private router: Router,
    private el: ElementRef) { }

  ngOnInit(): void {
    this.uploadService.uploadComplete = false;
    this.attachment.totalSize = this.uploadService.filesSize;
    this.attachment.totalCount = this.uploadService.uploader.queue.length;
    this.prepareFileName();
    this.getAttachmentAndStartUplaod();
    this.getPhrase();
  }

  ngAfterViewInit(): void {
    this.el.nativeElement.scrollIntoView();
  }

  prepareFileName() {
    if (this.uploadService.uploader.queue.length > 1) {
      this.attachment.name =
        this.uploadService.uploader.queue.length + ' Files ' + new PrepareDatePipe().transform(new Date());
    } else {
      this.attachment.name = this.uploadService.uploader.queue[0].file.name.split('.').shift();
    }
  }

  /**
   * Get Attachment Details from server and then start uplaod
   */
  getAttachmentAndStartUplaod() {
    if (!this.uploadService.uploader.queue.length) {
      return;
    }

    this.attachmentService.getAttachment(this.attachment).subscribe((res: Attachment) => {
      this.attachment.attachmentId = res.attachmentId;
      this.uploadService.startUpload(res.attachmentId);
    });
  }

  /**
   * Get Phrase
   */
  getPhrase() {
    this.phrase = this.phraseGeneratorService.randomPhrase();
  }

  /**
   * Cancel or view Download
   */
  cancelOrViewDownload() {
    if (this.uploadService.uploadComplete) {
      // this.router.navigate(['../download', this.uploadService.attachmentId], { relativeTo: this.activateRoute });
      window.open(`${location.origin}/download/${this.uploadService.attachmentId}`);
    } else {
      this.dialogService.confirmationDialog({ title: 'Confirmation', message: 'Are you sure to Cancel?' }).subscribe((res) => {
        if (res) {
          this.router.navigate(['../'], { relativeTo: this.activateRoute });
        }
      });
    }
  }

  /**
   * lifecycle event fires when component is destroying
   */
  ngOnDestroy(): void {
    this.uploadService.reset();
    this.uploadService.uploader.clearQueue();
  }
}
