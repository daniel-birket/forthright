#!/usr/local/bin/bash
bn=$(basename $1 .in)
echo Testing $bn "..."
gforth < $bn.in | diff $bn.cmp -
