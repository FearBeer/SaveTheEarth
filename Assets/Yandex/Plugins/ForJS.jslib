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

});