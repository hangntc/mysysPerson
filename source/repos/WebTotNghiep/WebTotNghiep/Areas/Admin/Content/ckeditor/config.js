/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    // Define changes to default configuration here. For example:
    config.language = 'en';
    // config.uiColor = '#AADC6E';
    config.filebrowserBrowseUrl = "/Areas/Admin/content/ckfinder/ckfinder.html";
    config.filebrowserImageUrl = "/Areas/Admin/ckfinder/ckfinder.html?type=Images";
    config.filebrowserUploadUrl = "/Areas/Admin/content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";

};
