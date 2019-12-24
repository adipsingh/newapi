import { Component, OnInit } from '@angular/core';

import { DashboardService } from '../../services/dashboard.service';
import { FilesHistory } from '../../models';
import { FileStatus, FileStage } from '../../enum';
import { FormControl } from '@angular/forms';

interface FilesFilterModel {
  fileStatus: number[];
  fileType: FileType;
  uploadRange: Date[];
}

interface FileType {
  startDate: FormControl;
  endDate: FormControl;
}

@Component({
  selector: 'am-files-history',
  templateUrl: './files-history.component.html',
  styleUrls: ['./files-history.component.scss']
})
export class FilesHistoryComponent implements OnInit {

  maxDate = new Date();
  filesHistory: FilesHistory[];
  filteredFilesHistory: FilesHistory[];
  isThumbnailView = true;
  fileStage = FileStage;
  fileStatus = FileStatus;
  filesFilterModel: FilesFilterModel;

  constructor(public dashboardService: DashboardService) { }

  ngOnInit() {
    this.resetFilter();
    this.dashboardService.getFilesHistory().subscribe(res => {
      this.filteredFilesHistory = this.filesHistory = res;
    });
  }

  filterByFileStatus(value: boolean, fileStatus: FileStatus) {
    if (value) {
      if (!this.filesFilterModel.fileStatus.includes(fileStatus)) {
        this.filesFilterModel.fileStatus.push(fileStatus);
      }
    } else {
      if (this.filesFilterModel.fileStatus.includes(fileStatus)) {
        const INDEX = this.filesFilterModel.fileStatus.findIndex(f => f === fileStatus);
        this.filesFilterModel.fileStatus.splice(INDEX, 1);
      }
    }
  }

  clearFilter() {
    this.resetFilter();
  }

  resetFilter() {
    this.filesFilterModel = {
      fileStatus: [],
      fileType: {
        startDate: new FormControl(),
        endDate: new FormControl()
      },
      uploadRange: []
    };
  }

  applyFilter() {
    this.filteredFilesHistory = this.filesHistory;
    if (this.filesFilterModel.fileStatus.length) {
      this.filteredFilesHistory = this.filteredFilesHistory.filter(f => this.filesFilterModel.fileStatus.includes(f.status));
    }

    if (this.filesFilterModel.fileType.startDate.value && this.filesFilterModel.fileType.endDate.value) {
      this.filteredFilesHistory = this.filteredFilesHistory
        .filter(f => new Date(f.attachmentCreationDate) <= this.filesFilterModel.fileType.endDate.value &&
          new Date(f.attachmentCreationDate) >= this.filesFilterModel.fileType.startDate.value);
    }

    if (this.filesFilterModel.fileType.startDate.value) {
      this.filteredFilesHistory = this.filteredFilesHistory
        .filter(f => new Date(f.attachmentCreationDate) >= this.filesFilterModel.fileType.startDate.value);
    }

    if (this.filesFilterModel.fileType.endDate.value) {
      this.filteredFilesHistory = this.filteredFilesHistory
        .filter(f => new Date(f.attachmentCreationDate) <= this.filesFilterModel.fileType.endDate.value);
    }
  }

  viewFileHistory(type: string) {
    if (type === 'THUMBNAIL') {
      this.isThumbnailView = true;
    } else if (type === 'LIST') {
      this.isThumbnailView = false;
    }
  }

  whenSortByFileStagesChanges(value: FileStage) {
    switch (value) {
      case FileStage.NewestUpload:
        this.filteredFilesHistory = this.filteredFilesHistory
          .sort((a, b) => this.compareDesc(new Date(a.attachmentCreationDate), new Date(b.attachmentCreationDate)));
        break;
      case FileStage.OldestUpload:
        this.filteredFilesHistory = this.filteredFilesHistory
          .sort((a, b) => this.compareAsc(new Date(a.attachmentCreationDate), new Date(b.attachmentCreationDate)));
        break;
      case FileStage.NewestExpired:
        this.filteredFilesHistory = this.filteredFilesHistory
          .sort((a, b) => this.compareDesc(new Date(a.attachmentExpiriedOn), new Date(b.attachmentExpiriedOn)));
        break;
      case FileStage.OldestExpired:
        this.filteredFilesHistory = this.filteredFilesHistory
          .sort((a, b) => this.compareAsc(new Date(a.attachmentExpiriedOn), new Date(b.attachmentExpiriedOn)));
        break;
      case FileStage.NewestPurged:
        this.filteredFilesHistory = this.filteredFilesHistory
          .sort((a, b) => this.compareDesc(new Date(a.attachmentPurgedDate), new Date(b.attachmentPurgedDate)));
        break;
      case FileStage.OldestPurged:
        this.filteredFilesHistory = this.filteredFilesHistory
          .sort((a, b) => this.compareAsc(new Date(a.attachmentPurgedDate), new Date(b.attachmentPurgedDate)));
        break;
      case FileStage.MostDownload:
        this.filteredFilesHistory = this.filteredFilesHistory
          .sort((a, b) => this.compareDesc(a.totalDownload, b.totalDownload));
        break;
      case FileStage.LeastDownlaod:
        this.filteredFilesHistory = this.filteredFilesHistory
          .sort((a, b) => this.compareAsc(a.totalDownload, b.totalDownload));
        break;
    }
  }

  compareAsc(a, b) {
    if (a < b) {
      return -1;
    }
    if (a > b) {
      return 1;
    }
    return 0;
  }

  compareDesc(a, b) {
    if (a > b) {
      return -1;
    }
    if (a < b) {
      return 1;
    }
    return 0;
  }
}
