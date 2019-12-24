import { FileType } from '.';

export interface FileDetail extends FileType {
    id: number;
    fileSize: number;
    fileType: string;
    fileName: string;
    date: Date;
    status: number;
    attachmentId: number;
    fileURL: string;
}
