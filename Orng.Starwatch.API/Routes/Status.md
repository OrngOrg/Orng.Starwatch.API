# Overall progress

## Complete (10/33)
- [x] AccountRoute
- [x] AnnouncementRoute
- [x] BanDetailsRoute
- [x] BanListRoute
- [x] BanRoute
- [x] ChatRoute
- [x] LogRoute
- [x] MetaAuthenticationDetailsRoute
- [x] MetaEndpointsRoute
- [x] VersionRoute

## Unstable (1/33)
- [x] AccountDetailsRoute - DEL route can cause connection to close unexpectedly

## Untested (3/33)
- [x] MapSystemRoute - Needs a SystemWorld to test with, need to setup
- [x] MetaAuthenticationRoute - Requires SuperUser, need to setup
- [x] MetaGatewayRoute - Requires SuperUser, need to setup

## Failed (3/33)
- [x] AccountAuthorizationRoute - Fails to convert :account to an Account object
- [x] AccountProtectionRoute - :account fails to be replaced in MySQL, and causes syntax error
- [x] MapRoute - all values fail to be replaced in MySQL, and causes syntax error

## Remaining (16/33)
- [ ] PlayerAllRoute
- [ ] PlayerDetailsRoute
- [ ] PlayerKickRoute
- [ ] PlayerRoute
- [ ] RconRoute
- [ ] ServerListingRoute
- [ ] ServerRoute
- [ ] ServerStatisticsRoute
- [ ] ServerUptimeRoute
- [ ] SessionRoute
- [ ] WorldDetailsRoute
- [ ] WorldPlayerRoute
- [ ] WorldRoute
- [ ] WorldSearchRoute
- [ ] WorldWhitelistAccountRoute
- [ ] WorldWhitelistRoute
