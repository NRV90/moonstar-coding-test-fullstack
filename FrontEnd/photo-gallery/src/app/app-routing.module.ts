import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AddPostComponent } from './add-post/add-post.component';

const routes: Routes = [
  {    
    path: '',
    loadChildren: () => import('./newsfeed/newsfeed.module').then(m => m.NewsfeedPageModule)
  },
  {
    path: 'add-post',
    component: AddPostComponent
  },
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
