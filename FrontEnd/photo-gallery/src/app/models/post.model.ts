export class Post {
    constructor(content: string, photoUrl: string, id: number) {
        this.content = content
        this.photoUrl = photoUrl
        this.id = id
    }

    content: string;
    photoUrl: string;
    id: number;
}