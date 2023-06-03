#ifndef API_CLIENT_H
#define API_CLIENT_H

#include <BLEDevice.h>
#include <HTTPClient.h>

class ApiClient
{
private:
    char *postAddress;
    HTTPClient httpClient;

public:
    ApiClient(const char *apiBaseUrl, const char *myId);
    ~ApiClient();
    int sendLocalization(BLEAdvertisedDevice *device);
};
#endif /* API_CLIENT_H */