import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { HomePage } from "./pages/home/home.page";
import { LojasComponent } from "./pages/lojas/lojas.component";
import { cdPage } from './pages/cd/cd.page';

const appRoutes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "home", component: HomePage },
  { path: "lojas", component: LojasComponent },
  { path: "cds", component: cdPage },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class Routing {}
