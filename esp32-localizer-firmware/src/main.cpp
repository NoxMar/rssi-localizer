#include "config.h"
#include "util.h"
#include "setup_logging.h"
#include "bluetooth_scanner.h"

RssiScanner scanner(SCAN_DURATION, SCAN_ACTIVE_MODE);

void setup()
{
  Serial.begin(SERIAL_BAUD_RATE);
  setupLogging(LOG_LEVEL_VERBOSE, &Serial);
  delay(INITIAL_DELAY); // wait for serial and WiFi to stabilize
  setupWiFi();
}

void loop()
{
  scanner.scan();
}