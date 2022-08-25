import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/post.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  private postsEndpoint: string = 'https://localhost:5001/posts'

  constructor(private httpClient: HttpClient) { }

  public getPosts(skip: number, take: number): Observable<Post[]> {
    return this.httpClient.get<Post[]>(this.postsEndpoint, { params: { skip: skip, take: take } });
  }

  public findById(id: number): Observable<Post> {
    return this.httpClient.get<Post>(this.postsEndpoint + '/getbyid', { params: { id: id } });
  }

  public addPost(file: any, post: Post): Observable<any> {
    let formData: FormData = new FormData();
    if (file) {
      formData.append("document", file, file.name);
    }
    formData.append("content", post.content);
    return this.httpClient.post(this.postsEndpoint, formData);
  }

  public updatePost(file: any, post: Post, photoUrl: string, id: number): Observable<any> {
    let formData: FormData = new FormData();
    if (file) {
      formData.append("document", file, file.name);
    }

    formData.append("content", post.content);
    formData.append("filePath", photoUrl);
    formData.append("id", id.toString());
    return this.httpClient.patch(this.postsEndpoint, formData);
  }

  public delete(postId: number): Observable<any> {
    return this.httpClient.delete<any>(this.postsEndpoint, { params: { id: postId } });
  }
}
