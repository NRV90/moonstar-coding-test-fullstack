import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../models/post.model';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.scss'],
})
export class EditPostComponent implements OnInit {

  private postId: number;
  public post: Post;

  constructor(private postService: PostsService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.subscribeToParameterChange();
  }

  private subscribeToParameterChange() {
    this.activatedRoute.queryParams.subscribe((params) => {
      this.postId = params["id"];
      this.getPost();
    });
  }

  private getPost(): void {
    if (!this.postId) return;

    this.postService.findById(this.postId).subscribe((res) => {
      this.post = res;
    });
  }

  updatePost(event: any) {
    if (!event) return;

    this.postService.updatePost(event.file, event.post, this.post.photoUrl, this.post.id)
      .subscribe(() => this.router.navigate(['newsfeed'], { replaceUrl: true }))
  }
}
