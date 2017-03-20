window.filter = function() {
  function apply() {
    var dataItem = $('#culture').data('kendoComboBox').dataItem();
    var regions = $('#region').data('kendoAutoComplete').value();

    window.AdminPage.kendo_tree.load(null, dataItem ? dataItem.Id : null, regions, null);
  }

  var initFn = function() {
    var cultureDataSrc = QP.Data.createDataSource(MvcJs.Dictionary.AjaxCultures(), null, function (data) {
      return data.List;
    });

    $('#culture').kendoComboBox({
      dataTextField: 'Title',
      dataValueField: 'Id',
      dataSource: cultureDataSrc
    });

    $('#region').kendoAutoComplete({
      minLength: 2,
      separator: ', ',
      filter: 'contains',
      dataSource: QP.Data.createDataSource(MvcJs.Dictionary.AjaxKendoUIRegions(), null, function(data) {
        var result = [];
        $.each(data.List, function(i, entry) {
          if (result.indexOf(entry.Title) === -1) {
            result.push(entry.Title);
          }
        });

        return result;
      })
    });

    $('#filter #applyFilter').bind('click', apply);
    $('#filter #btnRefreshCulture').bind('click', cultureDataSrc.read);
  };

  return {
    init: initFn
  };
}();
