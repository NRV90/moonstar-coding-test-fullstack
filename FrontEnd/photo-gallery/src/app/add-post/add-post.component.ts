import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Post } from '../models/post.model';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss'],
})
export class AddPostComponent implements OnInit {

  public contentControl: FormControl = new FormControl({ value: '', disabled: false });
  public postForm: FormGroup;
  public supportedFileTypes = ['jpeg', 'png', 'jpg', 'tiff', 'tif'];
  public imageSrc: any;
  private file: File;

  constructor(private formBuilder: FormBuilder, private postService: PostsService, private router: Router) {
    this.postForm = this.formBuilder.group({
      contentControl: this.contentControl
    });
  }

  ngOnInit() {
  }

  addPost() {
    if (!this.file) return;
    this.postService.addPost(this.file, this.getPostFromForm())
      .subscribe(() => this.router.navigate(['newsfeed'], { replaceUrl: true }))
  }

  back() {
    this.router.navigate(['newsfeed'], { replaceUrl: true });
  }


  getPostFromForm(): Post {
    return new Post(this.contentControl.value, '');
  }

  onFileChanged(event: any) {
    const file: File = event.target.files[0]
    if (!file || !this.validateFileType(file)) return;
    this.file = file;
    this.previewPhoto(file)
  }

  previewPhoto(file: any) {
    const reader = new FileReader();
    reader.onload = e => this.imageSrc = reader.result;

    reader.readAsDataURL(file);
  }

  validateFileType(file: File): boolean {
    if (!file) return false;

    const extension = this.parseFileType(file);

    return this.supportedFileTypes.indexOf(extension) !== -1;
  }

  parseFileType(file: File): string {
    const fileType = file.type.split('/');

    if (!fileType || fileType.length < 1) return '';

    const extension = fileType[1];

    return extension;
  }
}
