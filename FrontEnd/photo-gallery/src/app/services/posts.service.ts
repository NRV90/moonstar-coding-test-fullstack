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

  public getPosts(): Observable<Post[]> {
    return this.httpClient.get<Post[]>(this.postsEndpoint);
  }

  public addPost(file: any, post: Post): Observable<any> {
    let formData: FormData = new FormData();
    formData.append("document", file, file.name);
    formData.append("content", post.content);
    return this.httpClient.post(this.postsEndpoint, formData);
  }
}
