
/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config.extraPlugins = 'syntaxhighlight';
    //config.syntaxhighlight_lang = 'csharp';
    //config.syntaxhighlight_hideControls = true;
    config.language = 'vi';

    CKFinder.setupCKEditor(null, '/Assets/admin/js/plugins/ckfinder/');
};
