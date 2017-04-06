import { PeopleScreeningPage } from './app.po';

describe('people-screening App', () => {
  let page: PeopleScreeningPage;

  beforeEach(() => {
    page = new PeopleScreeningPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
