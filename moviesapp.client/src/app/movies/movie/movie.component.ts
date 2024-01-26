import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-movie',
  standalone: true,
  imports: [
    CommonModule,
  ],
  template: `<p>movie works!</p>`,
  styleUrl: './movie.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovieComponent { }
