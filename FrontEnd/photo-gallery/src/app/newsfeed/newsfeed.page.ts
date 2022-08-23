import { Component, OnInit } from '@angular/core';
import { Post } from '../models/post.model';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-newsfeed',
  templateUrl: 'newsfeed.page.html',
  styleUrls: ['newsfeed.page.scss']
})
export class NewsfeedPage implements OnInit {

  constructor(private postService: PostsService) { }

  public posts: Post[] = [];

  ngOnInit(): void {
    this.getPosts();
  }

  private getPosts() {
    this.postService.getPosts()
      .subscribe(res => {
        if (!res) return;
        this.posts = res;
      })
  }
}
