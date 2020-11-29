import { ManageCloudDevicesTemplatePage } from './app.po';

describe('ManageCloudDevices App', function() {
  let page: ManageCloudDevicesTemplatePage;

  beforeEach(() => {
    page = new ManageCloudDevicesTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
