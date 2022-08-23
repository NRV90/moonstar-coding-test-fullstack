export class Post {
    constructor(content: string, photoUrl: string) {
        this.content = content
        this.photoUrl = photoUrl
    }

    content: string;
    photoUrl: string;
}