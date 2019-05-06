import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagesTabPage } from './messages-tab.page';

describe('MessagesTabPage', () => {
  let component: MessagesTabPage;
  let fixture: ComponentFixture<MessagesTabPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [MessagesTabPage],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessagesTabPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
