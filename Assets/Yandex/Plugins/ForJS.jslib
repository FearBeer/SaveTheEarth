mergeInto(LibraryManager.library, {

  SaveExternal: function (data) {
    var dataString = UTF8ToString(data);
    var gameData = JSON.parse(dataString);
    player.setData(gameData);
  },

  LoadExternal: function () {
    player.getData().then(data => {
        const JSONFromGame = JSON.stringify(data);
        gameInstance.SendMessage('DataManger', 'Load', JSONFromGame);
    });
  },

  GetLang: function() {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  }

});