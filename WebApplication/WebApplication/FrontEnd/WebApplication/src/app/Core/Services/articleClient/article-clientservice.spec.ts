import { TestBed } from '@angular/core/testing';

import { ArticleStoreService } from './article-client.service';

describe('ArticleStoreService', () => {
  let service: ArticleStoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArticleStoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
