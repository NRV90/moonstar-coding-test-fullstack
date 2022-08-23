import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPostComponent } from '../add-post/add-post.component';
import { NewsfeedPage as NewsfeedPage } from './newsfeed.page';

const routes: Routes = [
  {
    path: 'newsfeed',
    component: NewsfeedPage,
  },
  {
    path: '',
    redirectTo: 'newsfeed',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class NewsfeedPageRoutingModule { }
