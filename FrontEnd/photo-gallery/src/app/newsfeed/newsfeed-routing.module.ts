import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
export class NewsfeedPageRoutingModule {}
