import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  private accountService = inject(AccountService);
  loggedIn = false;
  model: any = {};

  onLogin() {
    this.accountService.onLogin(this.model).subscribe({
      next: response  => {
        console.log(response);
        this.loggedIn = true;
      },
      error: error => console.log(error),
      complete: () => console.log("User logged in")  
    })
  }
}