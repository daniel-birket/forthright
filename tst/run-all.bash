#!/usr/local/bin/bash
for test in *.in; do
    ./run-test.bash $test || exit 1
done
echo All Tests Passed
