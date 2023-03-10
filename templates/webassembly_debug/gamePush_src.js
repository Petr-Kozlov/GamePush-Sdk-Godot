/*(() =>
{
    "use strict";
    class e
    {
        constructor(e, t)
        {
            this.gs = e, 

            this.unity = t, 

            this.gs.player.ready.then((() =>
            {
                this.trigger("CallSDKReady"), 
                this.trigger("CallPlayerReady")
            })), 

            this.gs.player.on("change", (() => this.trigger("CallPlayerChange"))), this.gs.player.on("sync", (e =>
            {
                this.trigger(e ? "CallPlayerSyncComplete" : "CallPlayerSyncError")
            })),

            this.gs.player.on("load", (e =>
            {
                this.trigger(e ? "CallPlayerLoadComplete" : "CallPlayerLoadError")
            })), 

            this.gs.player.on("login", (e =>
            {
                this.trigger(e ? "CallPlayerLoginComplete" : "CallPlayerLoginError")
            })), 

            this.gs.player.on("fetchFields", (e =>
            {
                e ? this.trigger("CallPlayerFetchFieldsComplete", JSON.stringify(this.gs.player.fields.map((e => (
                {
                    ...e,
                    defaultValue: e.default
                }))))) : this.trigger("CallPlayerFetchFieldsError")
            })), 

            this.gs.leaderboard.on("open", (() => this.trigger("CallLeaderboardOpen"))), this.gs.achievements.on("open", (() => this.trigger("CallAchievementsOpen"))), this.gs.achievements.on("close", (() =>
            {
                this.trigger("CallAchievementsClose"), window.focus()
            })), 

            this.gs.achievements.on("unlock", (() => this.trigger("CallAchievementsUnlock"))), this.gs.achievements.on("error:unlock", (() => this.trigger("CallAchievementsUnlockError"))), this.gs.gamesCollections.on("open", (() => this.trigger("CallGamesCollectionsOpen"))), this.gs.gamesCollections.on("close", (() =>
            {
                this.trigger("CallGamesCollectionsClose"), window.focus()
            })), 

            this.gs.fullscreen.on("open", (() => this.trigger("CallFullscreenOpen"))), this.gs.fullscreen.on("close", (() => this.trigger("CallFullscreenClose"))), this.gs.fullscreen.on("change", (() => this.trigger("CallFullscreenChange"))), this.gs.ads.on("start", (() => this.trigger("CallAdsStart"))), this.gs.ads.on("close", (e =>
            {
                this.trigger("CallAdsClose", e), window.focus()
            })), 

            this.gs.ads.on("fullscreen:start", (() => this.trigger("CallAdsFullscreenStart"))), this.gs.ads.on("fullscreen:close", (e => this.trigger("CallAdsFullscreenClose", e))), this.gs.ads.on("preloader:start", (() => this.trigger("CallAdsPreloaderStart"))), this.gs.ads.on("preloader:close", (e => this.trigger("CallAdsPreloaderClose", e))), this.gs.ads.on("rewarded:start", (() => this.trigger("CallAdsRewardedStart"))), this.gs.ads.on("rewarded:close", (e => this.trigger("CallAdsRewardedClose", e))), this.gs.ads.on("rewarded:reward", (() => this.trigger("CallAdsRewardedReward", this.lastRewardedTag))), this.gs.ads.on("sticky:start", (() => this.trigger("CallAdsStickyStart"))), this.gs.ads.on("sticky:close", (() => this.trigger("CallAdsStickyClose"))), this.gs.ads.on("sticky:refresh", (() => this.trigger("CallAdsStickyRefresh"))), this.gs.ads.on("sticky:render", (() => this.trigger("CallAdsStickyRender"))), this.gs.socials.on("share", (e => this.trigger("CallSocialsShare", e))), this.gs.socials.on("post", (e => this.trigger("CallSocialsPost", e))), this.gs.socials.on("invite", (e => this.trigger("CallSocialsInvite", e))), this.gs.socials.on("joinCommunity", (e => this.trigger("CallSocialsJoinCommunity", e))), this.gs.on("change:language", (e => this.trigger("CallChangeLanguage", e))), this.gs.on("change:avatarGenerator", (e => this.trigger("CallChangeAvatarGenerator", e))), this.gs.on("pause", (() => this.trigger("CallOnPause"))), this.gs.on("resume", (() => this.trigger("CallOnResume")))
        }
        trigger(e, t)
        {
            this.unity.SendMessage("GameScoreSDK", e, this.toUnity(t))
        }
        toUnity(e)
        {
            switch (typeof e)
            {
            case "boolean":
                return String(e);
            case "number":
            case "string":
                return e;
            case "object":
                return JSON.stringify(e)
            }
            return e
        }
        Language()
        {
            return this.gs.language
        }
        AvatarGenerator()
        {
            return this.gs.avatarGenerator
        }
        PlatformType()
        {
            return this.gs.platform.type
        }
        PlatformHasIntegratedAuth()
        {
            return this.toUnity(this.gs.platform.hasIntegratedAuth)
        }
        PlatformIsExternalLinksAllowed()
        {
            return this.toUnity(this.gs.platform.isExternalLinksAllowed)
        }
        AppTitle()
        {
            return this.gs.app.title
        }
        AppDescription()
        {
            return this.gs.app.description
        }
        AppImage()
        {
            return this.gs.app.image
        }
        AppUrl()
        {
            return this.gs.app.url
        }
        PlayerGetID()
        {
            return this.gs.player.id
        }
        PlayerGetScore()
        {
            return this.gs.player.score
        }
        PlayerSetScore(e)
        {
            this.gs.player.score = Number(e)
        }
        PlayerAddScore(e)
        {
            this.gs.player.score += Number(e)
        }
        PlayerGetName()
        {
            return this.gs.player.name
        }
        PlayerSetName(e)
        {
            this.gs.player.name = e
        }
        PlayerGetAvatar()
        {
            return this.gs.player.avatar
        }
        PlayerSetAvatar(e)
        {
            this.gs.player.avatar = e
        }
        PlayerGet(e)
        {
            return this.toUnity(this.gs.player.get(e))
        }
        PlayerSet(e, t)
        {
            this.gs.player.set(e, t)
        }
        PlayerAdd(e, t)
        {
            this.gs.player.add(e, Number(t))
        }
        PlayerHas(e)
        {
            return this.toUnity(this.gs.player.has(e))
        }
        PlayerSetFlag(e, t)
        {
            this.gs.player.set(e, !Boolean(t))
        }
        PlayerToggle(e)
        {
            this.gs.player.toggle(e)
        }
        PlayerGetFieldName(e)
        {
            return this.gs.player.getFieldName(e)
        }
        PlayerGetFieldVariantName(e, t)
        {
            return this.gs.player.getFieldVariantName(e, t)
        }
        PlayerGetFieldVariantAt(e, t)
        {
            const r = this.gs.player.getField(e).variants[t];
            return r ? r.value : ""
        }
        PlayerGetFieldVariantIndex(e, t)
        {
            return this.gs.player.getField(e).variants.findIndex((e => e.value === t))
        }
        PlayerReset()
        {
            this.gs.player.reset()
        }
        PlayerRemove()
        {
            this.gs.player.remove()
        }
        PlayerSync(e = !1)
        {
            return this.gs.player.sync(
            {
                override: Boolean(e)
            })
        }
        PlayerLoad()
        {
            return this.gs.player.load()
        }
        PlayerLogin()
        {
            return this.gs.player.login()
        }
        PlayerFetchFields()
        {
            this.gs.player.fetchFields()
        }
        PlayerIsLoggedIn()
        {
            return this.toUnity(this.gs.player.isLoggedIn)
        }
        PlayerHasAnyCredentials(e)
        {
            return this.toUnity(this.gs.player.hasAnyCredentials)
        }
        PlayerIsStub(e)
        {
            return this.toUnity(this.gs.player.isStub)
        }
        LeaderboardOpen(e, t, r, s, i, a)
        {
            return this.gs.leaderboard.open(
            {
                id: this.gs.player.id,
                orderBy: e.split(",").map((e => e.trim())).filter((e => e)),
                order: t,
                limit: Number(r),
                withMe: s,
                includeFields: i.split(",").map((e => e.trim())).filter((e => e)),
                displayFields: a.split(",").map((e => e.trim())).filter((e => e))
            }).catch(console.warn)
        }
        LeaderboardFetch(e, t, r, s, i, a)
        {
            return this.gs.leaderboard.fetch(
            {
                id: this.gs.player.id,
                orderBy: t.split(",").map((e => e.trim())).filter((e => e)),
                order: r,
                limit: Number(s),
                withMe: i,
                includeFields: a.split(",").map((e => e.trim())).filter((e => e))
            }).then((t =>
            {
                this.trigger("CallLeaderboardFetchTag", e), this.trigger("CallLeaderboardFetch", JSON.stringify(t.players))
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallLeaderboardFetchError")
            }))
        }
        LeaderboardFetchPlayerRating(e, t, r)
        {
            return this.gs.leaderboard.fetchPlayerRating(
            {
                id: this.gs.player.id,
                orderBy: t.split(",").map((e => e.trim())).filter((e => e)),
                order: r
            }).then((t =>
            {
                this.trigger("CallLeaderboardFetchPlayerTag", e), this.trigger("CallLeaderboardFetchPlayer", t.player.position)
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallLeaderboardFetchPlayerError")
            }))
        }
        LeaderboardScopedOpen(e, t, r, s, i, a, l, n)
        {
            return this.gs.leaderboard.openScoped(
            {
                id: Number(e),
                tag: t,
                variant: r,
                order: s,
                limit: Number(i),
                includeFields: a.split(",").map((e => e.trim())).filter((e => e)),
                displayFields: l.split(",").map((e => e.trim())).filter((e => e)),
                withMe: n
            }).catch(console.warn)
        }
        LeaderboardScopedFetch(e, t, r, s, i, a, l)
        {
            return this.gs.leaderboard.fetchScoped(
            {
                id: Number(e),
                tag: t,
                variant: r,
                order: s,
                limit: Number(i),
                includeFields: a.split(",").map((e => e.trim())).filter((e => e)),
                withMe: l
            }).then((e =>
            {
                this.trigger("CallLeaderboardScopedFetchTag", t), this.trigger("CallLeaderboardScopedFetchVariant", r), this.trigger("CallLeaderboardScopedFetch", JSON.stringify(e.players))
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallLeaderboardScopedFetchError")
            }))
        }
        LeaderboardScopedPublishRecord(e, t, r, s, i, a, l, n, o, g)
        {
            return this.gs.leaderboard.publishRecord(
            {
                id: Number(e),
                tag: t,
                variant: r,
                override: Boolean(s),
                record:
                {
                    [i]: Number(a),
                    [l]: Number(n),
                    [o]: Number(g)
                }
            }).then((() =>
            {
                this.trigger("CallLeaderboardScopedPublishRecordComplete")
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallLeaderboardScopedPublishRecordError")
            }))
        }
        LeaderboardScopedFetchPlayerRating(e, t, r, s)
        {
            return this.gs.leaderboard.fetchPlayerRatingScoped(
            {
                id: Number(e),
                tag: t,
                variant: r,
                includeFields: s.split(",").map((e => e.trim())).filter((e => e))
            }).then((e =>
            {
                this.trigger("CallLeaderboardScopedFetchPlayerTag", t), this.trigger("CallLeaderboardScopedFetchPlayerVariant", r), this.trigger("CallLeaderboardScopedFetchPlayer", e.player.position)
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallLeaderboardFetchPlayerError")
            }))
        }
        AchievementsOpen()
        {
            return this.gs.achievements.open().catch(console.warn)
        }
        AchievementsFetch()
        {
            return this.gs.achievements.fetch().then((e =>
            {
                this.trigger("CallAchievementsFetch", JSON.stringify(e.achievements)), this.trigger("CallAchievementsFetchGroups", JSON.stringify(e.achievementsGroups)), this.trigger("CallPlayerAchievementsFetch", JSON.stringify(e.playerAchievements))
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallAchievementsFetchError")
            }))
        }
        AchievementsUnlock(e)
        {
            const t = parseInt(e, 10) || 0,
                r = t > 0 ?
                {
                    id: t
                } :
                {
                    tag: e
                };
            return this.gs.achievements.unlock(r).then((t =>
            {
                t.success ? this.trigger("CallAchievementsUnlock", e) : this.trigger("CallAchievementsUnlockError")
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallAchievementsUnlockError")
            }))
        }
        PaymentsFetchProducts()
        {
            return this.gs.payments.fetchProducts().then((e =>
            {
                this.trigger("CallPaymentsFetchProducts", JSON.stringify(e.products)), this.trigger("CallPaymentsFetchPlayerPurcahses", JSON.stringify(e.playerPurchases))
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallPaymentsFetchProductsError")
            }))
        }
        PaymentsPurchase(e)
        {
            const t = parseInt(e, 10) || 0,
                r = t > 0 ?
                {
                    id: t
                } :
                {
                    tag: e
                };
            return this.gs.payments.purchase(r).then((t =>
            {
                if (t.success) return this.trigger("CallPaymentsPurchase", e), void window.focus();
                this.trigger("CallPaymentsPurchaseError"), window.focus()
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallPaymentsPurchaseError"), window.focus()
            }))
        }
        PaymentsConsume(e)
        {
            const t = parseInt(e, 10) || 0,
                r = t > 0 ?
                {
                    id: t
                } :
                {
                    tag: e
                };
            return this.gs.payments.consume(r).then((t =>
            {
                if (t.success) return this.trigger("CallPaymentsConsume", e), void window.focus();
                this.trigger("CallPaymentsConsumeError")
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallPaymentsConsumeError")
            }))
        }
        PaymentsIsAvailable()
        {
            return this.toUnity(this.gs.payments.isAvailable)
        }
        FullscreenOpen()
        {
            return this.gs.fullscreen.open()
        }
        FullscreenClose()
        {
            return this.gs.fullscreen.close()
        }
        FullscreenToggle()
        {
            return this.gs.fullscreen.toggle()
        }
        AdsShowFullscreen()
        {
            return this.gs.ads.showFullscreen()
        }
        AdsShowRewarded(e)
        {
            return this.lastRewardedTag = e, this.gs.ads.showRewardedVideo()
        }
        AdsShowPreloader()
        {
            return this.gs.ads.showPreloader()
        }
        AdsShowSticky()
        {
            return this.gs.ads.showSticky()
        }
        AdsCloseSticky()
        {
            return this.gs.ads.closeSticky()
        }
        AdsRefreshSticky()
        {
            return this.gs.ads.refreshSticky()
        }
        AdsIsAdblockEnabled()
        {
            return this.toUnity(this.gs.ads.isAdblockEnabled)
        }
        AdsIsStickyAvailable()
        {
            return this.toUnity(this.gs.ads.isStickyAvailable)
        }
        AdsIsFullscreenAvailable()
        {
            return this.toUnity(this.gs.ads.isFullscreenAvailable)
        }
        AdsIsRewardedAvailable()
        {
            return this.toUnity(this.gs.ads.isRewardedAvailable)
        }
        AdsIsPreloaderAvailable()
        {
            return this.toUnity(this.gs.ads.isPreloaderAvailable)
        }
        AdsIsStickyPlaying()
        {
            return this.toUnity(this.gs.ads.isStickyPlaying)
        }
        AdsIsFullscreenPlaying()
        {
            return this.toUnity(this.gs.ads.isFullscreenPlaying)
        }
        AdsIsRewardedPlaying()
        {
            return this.toUnity(this.gs.ads.isRewardedPlaying)
        }
        AdsIsPreloaderPlaying()
        {
            return this.toUnity(this.gs.ads.isPreloaderPlaying)
        }
        AnalyticsHit(e)
        {
            return this.gs.analytics.hit(e)
        }
        AnalyticsGoal(e, t)
        {
            return this.gs.analytics.goal(e, t)
        }
        SocialsShare(e, t, r)
        {
            return this.gs.socials.share(
            {
                text: e,
                url: t,
                image: r
            })
        }
        SocialsPost(e, t, r)
        {
            return this.gs.socials.post(
            {
                text: e,
                url: t,
                image: r
            })
        }
        SocialsInvite(e, t, r)
        {
            return this.gs.socials.invite(
            {
                text: e,
                url: t,
                image: r
            })
        }
        SocialsJoinCommunity()
        {
            return this.gs.socials.joinCommunity()
        }
        SocialsCommunityLink()
        {
            return this.toUnity(this.gs.socials.communityLink)
        }
        SocialsIsSupportsNativeShare()
        {
            return this.toUnity(this.gs.socials.isSupportsNativeShare)
        }
        SocialsIsSupportsNativePosts()
        {
            return this.toUnity(this.gs.socials.isSupportsNativePosts)
        }
        SocialsIsSupportsNativeInvite()
        {
            return this.toUnity(this.gs.socials.isSupportsNativeInvite)
        }
        SocialsCanJoinCommunity()
        {
            return this.toUnity(this.gs.socials.canJoinCommunity)
        }
        SocialsIsSupportsNativeCommunityJoin()
        {
            return this.toUnity(this.gs.socials.isSupportsNativeCommunityJoin)
        }
        GamesCollectionsOpen(e)
        {
            const t = parseInt(e, 10) || 0,
                r = t > 0 ?
                {
                    id: t
                } :
                {
                    tag: e || "ANY"
                };
            return this.gs.gamesCollections.open(r)
        }
        GamesCollectionsFetch(e)
        {
            const t = parseInt(e, 10) || 0,
                r = t > 0 ?
                {
                    id: t
                } :
                {
                    tag: e
                };
            return this.gs.gamesCollections.fetch(r).then((t =>
            {
                this.trigger("CallGamesCollectionsFetchTag", e), this.trigger("CallGamesCollectionsFetch", JSON.stringify(t))
            })).catch((e =>
            {
                console.warn(e), this.trigger("CallGamesCollectionsFetchError")
            }))
        }
        ChangeLanguage(e)
        {
            return this.gs.changeLanguage(e)
        }
        ChangeLanguageByCode(e = "")
        {
            return this.gs.changeLanguage(e.toLowerCase())
        }
        ChangeAvatarGenerator(e)
        {
            return this.gs.changeAvatarGenerator(e)
        }
        LoadOverlay()
        {
            return this.gs.loadOverlay()
        }
        IsPaused()
        {
            return this.toUnity(this.gs.isPaused)
        }
        Pause()
        {
            return this.gs.pause()
        }
        Resume()
        {
            return this.gs.resume()
        }
        IsMobile()
        {
            return this.toUnity(this.gs.isMobile)
        }
        ServerTime()
        {
            return this.toUnity(this.gs.serverTime)
        }
        IsDev()
        {
            return this.toUnity(this.gs.isDev)
        }
        IsAllowedOrigin()
        {
            return this.toUnity(this.gs.isAllowedOrigin)
        }
    }
    window.GameScoreUnity = e, window.GameScoreUnity = e
})();
//# sourceMappingURL=gamescore-unity.js.map*/