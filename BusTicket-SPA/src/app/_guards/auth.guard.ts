import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AuthService } from "../_services/auth.service";
import { AlertifyService } from "../_services/alertify.service";

@Injectable({
  providedIn: "root"
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(next: ActivatedRouteSnapshot): boolean {
    // const roles = next.firstChild.data["roles"] as Array<string>;
    // if (roles) {
    //   const match = this.authService.roleMatch(roles);
    //   if (match) {
    //     return true;
    //   } else {
    //     this.router.navigate(["login"]);
    //   }
    // }

    if (this.authService.loggedIn()) {
      return true;
    }

    this.router.navigate(["login"]);
    return false;
  }
}
