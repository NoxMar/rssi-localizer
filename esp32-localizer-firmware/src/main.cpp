#include <Arduino.h>
#include <ArduinoLog.h>

#include "config.h"
#include "setup_logging.h"

void setup()
{
  Serial.begin(SERIAL_BAUD_RATE);
  setupLogging(LOG_LEVEL_VERBOSE, &Serial);
  delay(INITIAL_DELAY); // wait for serial to stabilize
}

void loop()
{
  Log.verboseln("Keep alive");
  delay(1000);
}