#include <Arduino.h>
#include <ArduinoLog.h>

#include "setup_logging.h"

void setup()
{
  Serial.begin(9600);
  setupLogging(LOG_LEVEL_VERBOSE, &Serial);
  delay(100); // wait for serial to stabilize
}

void loop()
{
  Log.verboseln("Keep alive");
  delay(1000);
}