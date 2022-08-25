import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {

  @Input() content: string;
  @Input() photoUrl: string = '../assets/img/no-posts.png';
  @Input() postId: number;
  @Output() openModal: EventEmitter<number> = new EventEmitter<number>();

  public isModalOpen: boolean = false;

  constructor(private router: Router) { }

  ngOnInit() { }

  updateUrl(event: any) {
    this.photoUrl = '../assets/img/no-posts.png';
  }

  editPost() {
    this.router.navigate(['edit-post'], { queryParams: { id: this.postId } })
  }

  viewPost(isOpen: boolean) {
    this.isModalOpen = isOpen;
  }

  setOpen(isOpen: boolean) {
    this.isModalOpen = isOpen;
  }

  delete() {
    this.openModal.emit(this.postId);
  }
}
