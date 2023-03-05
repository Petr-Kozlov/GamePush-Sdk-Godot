
class GamePush {

	isReady = false;
	sdk = undefined;

	constructor(gp){
		this.sdk = gp;
	}


	Print(){
		console.log("SDK: ")
		console.log(this.sdk);
	}

	IsReady(){
		return this.isReady;
	}

	Init(readyCall){

		gp.player.ready.then(() =>
        {
        	console.log("READY SDK");
        	this.isReady = true;
        	readyCall();
            //this.trigger("CallSDKReady"), this.trigger("CallPlayerReady")
        });

	   /* // Wait while the player syncs with the server
	    await gp.player.ready;

	    // Show the ad preloader and wait until it ends
	    await gp.ads.showPreloader();
	    // Show the sticky banner (then it will update itself)
	    gp.ads.showSticky();

	    // You can start the game :)*/
	}
}