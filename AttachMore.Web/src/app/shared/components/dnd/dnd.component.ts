import { Component, OnInit, OnDestroy, ViewChild, ElementRef, Input } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { trigger, transition, style, animate } from '@angular/animations';
import { Router } from '@angular/router';

import { UploadService } from '../../../services/upload.service';
import { AuthService } from '../../../services/auth.service';
import { AuthDialogService } from '../../../services/auth-dialog.service';
import { DataUsage } from '../../../models';

@Component({
  selector: 'am-dnd',
  templateUrl: './dnd.component.html',
  styleUrls: ['./dnd.component.scss'],
  animations: [
    trigger('items', [
      transition(':enter', [
        style({ transform: 'scale(0.5)', opacity: 0 }),
        animate('750ms cubic-bezier(.8, -0.6, 0.2, 1.5)'),
        style({ transform: 'scale(1)', opacity: 1 })
      ]), transition(':leave', [
        style({ transform: 'scale(1)', opacity: 1, height: '*' }),
        animate('750ms cubic-bezier(.8, -0.6, 0.2, 1.5)',
          style({
            transform: 'scale(0.5)', opacity: 0,
            height: '0px', margin: '0px'
          }))
      ])
    ])
  ]
})
export class DndComponent implements OnInit, OnDestroy {

  @Input() dataUsage: DataUsage;
  @ViewChild('fileUpload') fileUpload: ElementRef;

  constructor(private router: Router,
    public uploadService: UploadService,
    public authService: AuthService,
    private authDialogService: AuthDialogService) { }

  ngOnInit() {
  }

  /**
   * -- Tracking ngFor
   * @param index
   * @param item
   */
  trackByFn(index, item) {
    return index;
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.uploadService.uploader.queue, event.previousIndex, event.currentIndex);
  }

  /**
   * -- redirect to upload page
   */
  redirectToUploadPage() {
    this.router.navigate(['/upload_progress']);
  }

  /**
   * fires when select files button clicked
   */
  whenSelectFilesClicked() {
    this.clickFileEl();
  }

  /**
   * Fire click on file element
   */
  clickFileEl() {
    this.fileUpload.nativeElement.click();
  }

  ngOnDestroy(): void {
  }
}
