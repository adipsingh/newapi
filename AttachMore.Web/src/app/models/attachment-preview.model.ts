import { FileDetail } from './file-detail.model';

export interface AttachmentPreview {
    attachmentId: number;
    attachmentName: string;
    attachmentSize: number;
    status: number;
    fileDetails: FileDetail[];
}
