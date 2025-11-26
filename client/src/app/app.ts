import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { Header } from '../layout/header/header';
import { Footer } from '../layout/footer/footer';

@Component({
  imports: [Header, Footer, RouterOutlet],
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {}
