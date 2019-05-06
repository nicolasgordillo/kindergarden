import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs.page';

const routes: Routes = [
  {
    path: 'tabs',
    component: TabsPage,
    children: [
      {
        path: 'notifications-tab',
        children: [
          {
            path: '',
            loadChildren: '../notifications-tab/notifications-tab.module#NotificationsTabPageModule'
          }
        ]
      },
      {
        path: 'messages-tab',
        children: [
          {
            path: '',
            loadChildren: '../messages-tab/messages-tab.module#MessagesTabPageModule'
          }
        ]
      },
      {
        path: '',
        redirectTo: '/tabs/notifications-tab',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '',
    redirectTo: '/tabs/notifications-tab',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class TabsPageRoutingModule {}
