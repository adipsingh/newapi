import { Component, Input } from '@angular/core';
import { FileItem } from 'ng2-file-upload';

import { ICONS_MAPPER } from '../../../untility';
import { AmFileType } from '../../../enum';

@Component({
  selector: 'am-file',
  templateUrl: './am-file.component.html',
  styleUrls: ['./am-file.component.scss']
})
export class AmFileComponent {

  fileItem: FileItem;
  filetype: AmFileType = AmFileType.normal;
  amfileType = AmFileType;
  url: string;
  sizeInKb: number;
  name: string;
  extension: string;
  icons = ICONS_MAPPER;

  // tslint:disable-next-line:no-input-rename
  @Input('uploadedFile') set uploadedFile(file: FileItem) {
    this.fileItem = file;
    if (this.fileItem) {
      console.log(this.fileItem.file.type);
      this.prepareImageUrl();
      this.prepareVideoUrl();
      this.getSize();
      this.getNameandExtension();
    }
  }

  constructor() {
  }

  /**
    * -- prepare image url for its preview
    */
  prepareImageUrl() {
    if (this.fileItem.file.type.includes('image')) {
      this.filetype = AmFileType.image;
      this.prepareUrl();
    }
  }

  /**
    * -- prepare video url for its preview
    */
  prepareVideoUrl() {
    if (this.fileItem.file.type.includes('video')) {
      this.filetype = AmFileType.video;
      this.prepareUrl();
    }
  }

  /**
   * -- prepare file url for its preview
   */
  prepareUrl() {
    const fileReader = new FileReader();
    fileReader.readAsDataURL(this.fileItem._file);
    fileReader.onload = (event: any) => {
      this.url = event.target.result.toString();
    };
  }

  /**
   * get File Size
   */
  getSize() {
    this.sizeInKb = +((this.fileItem.file.size / 1024).toFixed(2));
  }

  /**
   * get File Name
   */
  getNameandExtension() {
    [this.name, this.extension] = this.fileItem.file.name.split('.');
  }

  /**
   * -- delete file when delete icon is clicked
   */
  whenDeletedClicked() {
    this.fileItem.remove();
  }
}
