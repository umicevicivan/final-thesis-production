/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { WorkersService } from './workers.service';

describe('Service: Workers', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WorkersService]
    });
  });

  it('should ...', inject([WorkersService], (service: WorkersService) => {
    expect(service).toBeTruthy();
  }));
});
