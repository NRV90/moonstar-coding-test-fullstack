import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Post } from '../models/post.model';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.scss'],
})
export class PostFormComponent implements OnChanges {

  @Output() submit: EventEmitter<any> = new EventEmitter<any>()
  @Input() post: Post;

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
  ngOnChanges(changes: SimpleChanges): void {
    var postChanges = changes['post'];

    if (postChanges && postChanges.currentValue) {
      this.setFormValues(postChanges.currentValue);
    }
  }

  updateUrl() {
    this.imageSrc = '../assets/img/no-posts.png';
  }

  setFormValues(post: Post) {
    this.contentControl.setValue(post.content);
    this.imageSrc = post.photoUrl;
  }

  addPost() {
    this.submit.emit({ file: this.file, post: this.getPostFromForm() });
  }

  back() {
    this.router.navigate(['newsfeed'], { replaceUrl: true });
  }


  getPostFromForm(): Post {
    return new Post(this.contentControl.value, '', 0);
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
