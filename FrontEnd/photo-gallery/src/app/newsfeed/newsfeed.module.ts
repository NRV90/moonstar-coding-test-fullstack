import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NewsfeedPageRoutingModule } from './newsfeed-routing.module';
import { NewsfeedPage } from './newsfeed.page';
import { PostComponent } from '../post/post.component';

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
    NewsfeedPageRoutingModule
  ],
  declarations: [NewsfeedPage, PostComponent]
})
export class NewsfeedPageModule {}
