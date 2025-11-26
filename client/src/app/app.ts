import { Component } from '@angular/core';

import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';

@Component({
  imports: [Header, Footer],
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {}
