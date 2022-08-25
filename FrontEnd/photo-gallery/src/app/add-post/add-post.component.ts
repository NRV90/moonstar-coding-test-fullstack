import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss'],
})
export class AddPostComponent implements OnInit {

  constructor(private postService: PostsService, private router: Router) {  }

  ngOnInit() {
  }

  addPost(event: any) {
    if (!event) return;
    this.postService.addPost(event.file, event.post)
      .subscribe(() => this.router.navigate(['newsfeed'], { replaceUrl: true }))
  }
}
