#include <Arduino.h>
#include <ArduinoLog.h>
#include <WiFi.h>

#include "config.h"
#include "util.h"
#include "setup_logging.h"
#include "bluetooth_scanner.h"

RssiScanner scanner(SCAN_DURATION, SCAN_ACTIVE_MODE);

void setup()
{
  Serial.begin(SERIAL_BAUD_RATE);
  setupLogging(LOG_LEVEL_VERBOSE, &Serial);
  Log.infoln("Starting initialization");
  Log.infoln("My MAC address is: %s", WiFi.macAddress().c_str());
  delay(INITIAL_DELAY); // wait for serial and WiFi to stabilize
  setupWiFi();
  Log.infoln("Initalized");
}

void loop()
{
  scanner.scan();
}