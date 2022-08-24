import { Component } from '@angular/core';
import { Post } from '../models/post.model';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-newsfeed',
  templateUrl: 'newsfeed.page.html',
  styleUrls: ['newsfeed.page.scss']
})
export class NewsfeedPage {

  constructor(private postService: PostsService) { }
  private skip = 0;
  private take = 3;

  public posts: Post[] = [];

  ionViewDidEnter() {
    this.getPosts(this.skip * this.take, this.take);
  }

  loadData(event) {
    setTimeout(() => {
      this.skip++
      this.getPosts(this.skip * this.take, this.take);
      event.target.complete();
    }, 500);
  }

  private getPosts(skip: number, take: number) {
    this.postService.getPosts(skip, take)
      .subscribe(res => {
        if (!res) return;
        this.posts = this.posts.concat(res);
      })
  }
}
