---
title: 'Exercise 04: Make things secure'
layout: default
nav_order: 6
has_children: true
---

# Exercise 04 - Make things secure

## Lab Scenario

Repository security is something development teams may overlook. In this exercise, you will make use of several capabilities GitHub has to secure existing repositories. You will protect important branches, preventing users from checking directly into branches like `main`. Instead, developers will create feature branches and build pull requests that team members can review before code check-in. You will enable manual gating before deployment to production, adding an additional step for manual checks. You will create a security policy for the repository, providing appropriate contact information in the event that someone finds a security vulnerability in repository code. You will also enable Depandabot alerts and show how to run code scanning workflows using CodeQL. Finally, you will create an outside-in availability test in Application Insights to check whether applications are running as expected.

## Objectives

After you complete this lab, you will be able to:

* Protect important branches in GitHub repositories
* Create a security policy for a GitHub repository
* Enable Depandabot alerts on a GitHub repository
* Create outside-in availability testing via Application Insights

## Lab Duration

* **Estimated Time:** 60 minutes
