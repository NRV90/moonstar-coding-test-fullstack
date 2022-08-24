import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { PostComponent } from '../post/post.component';
import { NewsfeedPageRoutingModule } from './newsfeed-routing.module';
import { NewsfeedPage } from './newsfeed.page';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    NewsfeedPageRoutingModule
  ],
  declarations: [NewsfeedPage, PostComponent]
})
export class NewsfeedPageModule { }
