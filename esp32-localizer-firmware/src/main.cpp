#include <Arduino.h>
#include <ArduinoLog.h>
#include <WiFi.h>

#include "config.h"
#include "util.h"
#include "setup_logging.h"
#include "bluetooth_scanner.h"
#include "ApiClient.h"

RssiScanner scanner(SCAN_DURATION, SCAN_ACTIVE_MODE);
ApiClient *apiClient;
void setup()
{
  Serial.begin(SERIAL_BAUD_RATE);
  setupLogging(LOG_LEVEL_VERBOSE, &Serial);
  Log.infoln("Starting initialization");
  delay(INITIAL_DELAY); // wait for serial and WiFi to stabilize
  setupWiFi();
  Log.infoln("My MAC address is: %s", WiFi.macAddress().c_str());
  apiClient = new ApiClient(API_BASE_URL, WiFi.macAddress().c_str());
  Log.infoln("Initalized");
}

void postOnFound(RssiScanner *context, BLEAdvertisedDevice *device)
{
  Log.verboseln("attempting to post result for: %s", device->getAddress().toString().c_str());
  int httpCode = apiClient->sendLocalization(device);
  if (httpCode < 200 || httpCode > 300)
  {
    Log.errorln("Request FAILED with code: %d", httpCode);
  }
  else
  {
    Log.verboseln("Request succeeded with code: %d", httpCode);
  }
}

void loop()
{
  scanner.scan(postOnFound);
}