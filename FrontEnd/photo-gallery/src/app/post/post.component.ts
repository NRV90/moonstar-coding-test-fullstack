import { Component, Input, OnInit } from '@angular/core';
import { Dialogs } from '@awesome-cordova-plugins/dialogs/ngx';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {

  @Input() content: string;
  @Input() photoUrl: string = '../assets/img/no-posts.png';
  
  public isModalOpen: boolean = false;

  constructor() { }

  ngOnInit() { }

  updateUrl(event: any) {
    this.photoUrl = '../assets/img/no-posts.png';
  }

  editPost(isOpen: boolean) {
    this.isModalOpen = isOpen;
  }

  setOpen(isOpen: boolean) {
    this.isModalOpen = isOpen;
  }
}
