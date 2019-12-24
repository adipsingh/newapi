import { Injectable } from '@angular/core';

import { FileUploader } from 'ng2-file-upload';

import { URLS } from '../configuration';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class UploadService {

    hasDropZoneOver = false;
    uploader: FileUploader;
    filesSize = 0;
    uploadComplete = false;
    prevProgress = 0;
    timestamp: number;
    speed = 0;
    attachmentId: number;
    attachmentName = '';

    /**
     * Get count of files which are uploaded
     */
    get uploadFilesCount(): number {
        let count = 1;
        for (const file of this.uploader.queue) {
            if (file.isSuccess) {
                count++;
            }
        }
        return count;
    }

    /**
     * Get perentage of files which are uploaded
     */
    get uploadedFilesPercentage(): number {
        return this.uploadFilesCount * 100 / this.uploader.queue.length;
    }

    /**
     * Get uploaded files size
     */
    get uploadedSize(): number {
        if (!this.filesSize) {
            return 0;
        }
        return +(this.filesSize * this.uploader.progress / 100).toFixed(2);
    }

    get uploadTime(): number {
        if (!this.filesSize || !this.speed) {
            return 0;
        }
        return Math.ceil(this.filesSize / this.speed);
    }

    /**
     * get network speed percentage
     */
    get networkSpeedProgress(): number {
        if (!this.speed) {
            return 0;
        }
        return this.speed * 100 / (1024);
    }

    constructor(private authService: AuthService) {
        this.initNg2Upload();
    }

    /**
     * initialize ng2 file upload
     */
    initNg2Upload() {
        this.uploader = new FileUploader({
            url: `${URLS.uploadFile}`,
            authToken: this.authService.token,
            disableMultipart: false
        });
        this.uploader.onAfterAddingFile = () => {
            this.totalFilesSize();
        };
        this.onBeforeUploadItem();
        this.onCompleteAll();
    }

    /**
     * fires when all files are uploaded
     */
    onCompleteAll() {
        this.uploader.onCompleteAll = () => {
            this.uploadComplete = true;
        };
    }
    /**
     * event fires before file upload
     * @param
     */
    onBeforeUploadItem() {
        this.uploader.onBeforeUploadItem = (item) => {
            item.withCredentials = false;
            this.timestamp = Date.now();
        };
    }

    /**
     * event fires when files is dragged over area
     */
    public fileOver(e: any): void {
        this.hasDropZoneOver = e;
    }

    /**
     * reset some global properties
     */
    reset() {
        this.filesSize = 0;
        this.prevProgress = 0;
        this.uploadComplete = false;
        this.timestamp = 0;
        this.speed = 0;
    }

    /**
     * starting upload
     * @param attachmentId
     */
    startUpload(attachmentId: number) {
        this.attachmentId = attachmentId;
        this.uploader.setOptions({ additionalParameter: { attachmentId: attachmentId } });
        this.uploader.uploadAll();
    }

    /**
     * Get total file size in MB
     */
    totalFilesSize(): void {
        let size = 0;
        this.uploader.queue.forEach((current, index) => {
            size += current.file.size;
        });
        this.filesSize = +(size / 1024 / 1024).toFixed(2);
    }

    /**
     * network speed
     */
    networkSpeed(): number {
        const progress = this.uploader.progress - this.prevProgress;
        if (progress <= 0) {
            return this.speed;
        }
        const duration = (Date.now() - this.timestamp) / 1000;
        const chunk = (progress) * this.filesSize / 100;
        this.prevProgress = this.uploader.progress;
        this.timestamp = Date.now();
        this.speed = +((chunk * 1024) / duration).toFixed(2); // speed in Kbs
        return this.speed;
    }

}
