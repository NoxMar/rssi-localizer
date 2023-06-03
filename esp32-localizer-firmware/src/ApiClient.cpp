#include "ApiClient.h"

#include <ArduinoLog.h>
#include <ArduinoJson.h>

#define BASE_ADDRESS_BUFFER_SIZE 120

StaticJsonDocument<512> doc;

ApiClient::ApiClient(const char *apiBaseUrl, const char *myId)
{
    postAddress = new char[BASE_ADDRESS_BUFFER_SIZE];
    snprintf(postAddress,
             BASE_ADDRESS_BUFFER_SIZE,
             "%s/sensor/%s/measurement",
             apiBaseUrl,
             myId);

    Log.infoln("Setting up API client with URL: %s", postAddress);
}

int ApiClient::sendLocalization(BLEAdvertisedDevice *device)
{
    doc.clear();
    doc["deviceUid"] = device->getAddress().toString().c_str();
    doc["rssi"] = device->getRSSI();
    String content;
    serializeJson(doc, content);
    httpClient.begin(postAddress);
    httpClient.addHeader("Content-Type", "application/json");
    return httpClient.POST(content);
}

ApiClient::~ApiClient()
{
    delete postAddress;
}