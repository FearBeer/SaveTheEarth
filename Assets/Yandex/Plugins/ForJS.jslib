mergeInto(LibraryManager.library, {

  SaveExternal: function(data) {
    var dataString = UTF8ToString(data);
    var gameData = JSON.parse(dataString);
    player.setData(gameData);
  },

  LoadExternal: function() {
    player.getData().then(data => {
        const JSONFromGame = JSON.stringify(data);
        gameInstance.SendMessage('DataManager', 'Load', JSONFromGame);
    });
  },

  RateGame: function() {
    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason);
            }
        })
  },

  GetLang: function() {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },

  ShowFullScreenAdvertising: function() {
    ysdk.adv.showFullscreenAdv({
      callbacks: {
          onOpen: function() {
            console.log("--------------- opened --------------");
            gameInstance.SendMessage('DataManager', 'PauseGame');
          },
          onClose: function(wasShown) {
            console.log("--------------- closed --------------");
            gameInstance.SendMessage('DataManager', 'ResumeGame');
            gameInstance.SendMessage('DataManager', 'ReloadScene');
          },
          onError: function(error) {
            console.log(error);
          }
      }
    })
  },

  RewardForVideo: function() {
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
          gameInstance.SendMessage('DataManager', 'PauseGame');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          gameInstance.SendMessage('DataManager', 'GiveReward');
        },
        onClose: () => {
          console.log('Video ad closed.');
          gameInstance.SendMessage('DataManager', 'ResumeGame');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
  },

});