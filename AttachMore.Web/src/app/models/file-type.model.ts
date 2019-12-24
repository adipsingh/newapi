import { AmFileType } from '../enum';

export interface FileType {
    extension: string;
    isImage: boolean;
    type: AmFileType;
}
