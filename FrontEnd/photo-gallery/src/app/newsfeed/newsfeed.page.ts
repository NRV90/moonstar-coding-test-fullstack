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

  public isModalOpenMap = new Map<number, boolean>()

  ionViewDidEnter() {
    this.getPosts(this.skip * this.take, this.take);
  }

  ionViewDidLeave() {
    this.skip = 0;
    this.take = 3;
    this.posts = [];
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
        res.forEach(item => {
          this.isModalOpenMap.set(item.id, false)
        })
        this.posts = this.posts.concat(res);
      })
  }

  setOpen(isOpen: boolean, postId: number) {
    this.isModalOpenMap[postId] = isOpen;
  }

  delete(postId: number) {
    this.isModalOpenMap[postId] = false;
    this.postService.delete(postId).subscribe(() => this.removePostFromArray(postId));
  }

  removePostFromArray(postId: number) {
    const deletedPost = this.posts.find(p => p.id == postId);
    const index = this.posts.indexOf(deletedPost);
    if (index > -1) {
      this.posts.splice(index, 1);
    }
    this.ionViewDidEnter();
  }
}
