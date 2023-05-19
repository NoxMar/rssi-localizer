#include <Arduino.h>
#include <ArduinoLog.h>

void printPrefix(Print *_logOutput, int logLevel);

void setup()
{
  // Setup logging
  Serial.begin(9600);
  Log.begin(LOG_LEVEL_VERBOSE, &Serial);
  Log.setPrefix(printPrefix);
  delay(100);
  Log.infoln("Starting setup");
  Log.infoln("Finishing setup");
}

void loop()
{
  Log.verboseln("Keep alive");
  delay(1000);
}

char timestampBuffer[25];

void printPrefix(Print *_logOutput, int logLevel)
{
  snprintf(timestampBuffer, 25, "%10dms:", millis());
  _logOutput->print(timestampBuffer);
}